export class SearchQuery extends SearchQueryBase {
  keyword: string = '';

}
export class SearchQueryBase {

  pageIndex: number = 0;

  pageSize: number = 10;

  sortField: string = '';

  isDesc: boolean = true;

  isActive: boolean = true;
}
