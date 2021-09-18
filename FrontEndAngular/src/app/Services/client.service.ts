import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private BUrl = 'https://localhost:44372/';
  private ApiUrl = 'api/Client/';
  constructor(private http: HttpClient) { }

  getListClient(): Observable<any>{
    return this.http.get(this.BUrl + this.ApiUrl);
  }
  getListClientxName(clientName : string): Observable<any>{
    return this.http.get(this.BUrl + this.ApiUrl + clientName);
  }
  SaveClient(client: any): Observable<any>{
    return this.http.post(this.BUrl + this.ApiUrl, client);
  }
  EditClient(client: any): Observable<any>{
    return this.http.put(this.BUrl + this.ApiUrl, client);
  }
  DeleteClient(id: number): Observable<any>{
    return this.http.delete(this.BUrl + this.ApiUrl + id);
  }
}
