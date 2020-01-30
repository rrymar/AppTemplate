import { HttpClient, HttpParams } from '@angular/common/http';;
import { Observable } from 'rxjs';
import { ResultsList } from './results-list';
import { saveFile } from '../file-utils';
import { SearchQuery } from './search-query';

export abstract class SearchService<T, TSearchQuery extends SearchQuery> {

  abstract getBasePath(): string;

  constructor(private httpClient: HttpClient) {
  }

  search(query: TSearchQuery): Observable<ResultsList<T>> {
    return this.httpClient.post<ResultsList<T>>(`${this.getBasePath()}/Search`, query);
  }

  export(query: TSearchQuery, exportPath: string = 'Export'): void {
    const exportQuery = {
      ...query,
      pageIndex: 0,
      pageSize: 10000,
    };

    let timeZone = '';
    try {
      timeZone = Intl.DateTimeFormat().resolvedOptions().timeZone;
    } catch { /*have an empty timeZone if not supported by browser*/ }

    this.httpClient.post(`${this.getBasePath()}/${exportPath}`, exportQuery,
        { responseType: 'blob', observe: 'response', headers: { timeZone } })
      .subscribe(saveFile);
  }

  protected createQuery(query: TSearchQuery): HttpParams {
    let httpQuery = new HttpParams();
    if (query) {
      for (const key in query) {
        if (key == 'constructor') {
          continue;
        }

        const value = query[key];
        if (value || (typeof value === 'boolean' && value === false)) {
          httpQuery = httpQuery.set(key.toString(), value.toString());
        }
      }
    }

    return httpQuery;
  }
}
