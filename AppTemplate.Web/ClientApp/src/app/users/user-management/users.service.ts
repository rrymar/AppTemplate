import { Injectable } from '@angular/core';
import { UsersStore, UsersState } from './users.store';
import { NgEntityService } from '@datorama/akita-ng-entity-service';

@Injectable({ providedIn: 'root' })
export class UsersService extends NgEntityService<UsersState> {

  constructor(protected store: UsersStore) {
    super(store);
  }

}
