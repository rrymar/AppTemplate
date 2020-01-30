import { SearchService } from 'app/core/search/search.service';
import { SearchQuery } from 'app/core/search/search-query';
import { UserModel } from '../user.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class UsersListService extends SearchService<UserModel, SearchQuery>{
  getBasePath = () => 'api/users';

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }
}
