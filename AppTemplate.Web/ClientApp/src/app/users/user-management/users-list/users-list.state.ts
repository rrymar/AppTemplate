import { State, Action, Selector, StateContext } from '@ngxs/store';
import { UserModel } from '../user.model';
import { UsersListService } from './users-list.service';
import { tap } from 'rxjs/operators';
import { produce } from 'immer';
import { LoadUsersAction } from './users-list.actions';

export class UsersList {
  items: UserModel[];
  isLoading: boolean;
  totalCount: number;
}

@State<UsersList>({
  name: 'users-list',
  defaults: {
    items: [],
    isLoading: false,
    totalCount: 0
  }
})
export class UsersListState {
  constructor(private service: UsersListService) {
  }

  @Selector()
  static items(state: UsersList): UserModel[] {
    return state.items;
  }

  @Selector()
  static totalCount(state: UsersList): number {
    return state.totalCount;
  }

  @Selector()
  static isLoading(state: UsersList): boolean {
    return state.isLoading;
  }

  @Action(LoadUsersAction)
  loadUsers(ctx: StateContext<UsersList>, action: LoadUsersAction) {
    ctx.setState(produce(ctx.getState(), draft => {
      draft.isLoading = true;
    }));

    return this.service.search(action.query)
      .pipe(tap(r => {
        ctx.setState(produce(ctx.getState(), draft => {
          draft.isLoading = false;
          draft.items = r.items;
          draft.totalCount = r.totalCount;
        }));
      }));
  }
}
