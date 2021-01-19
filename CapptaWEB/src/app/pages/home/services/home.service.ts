import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Sonda } from '../models/sonda';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private API_URL = environment.url;

  constructor(private http: HttpClient) { }


  monvimentar(sonda: Array<Sonda>): Observable<Array<string>> {
    return this.http.post<any>(this.API_URL, sonda);
  }

}
