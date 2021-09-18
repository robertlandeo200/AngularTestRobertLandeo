import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoansService {
  private BUrl = 'https://localhost:44372/';
  private ApiUrl = 'api/Loans/';
  constructor(private http: HttpClient) { }

  getListLoans(): Observable<any>{
    return this.http.get(this.BUrl + this.ApiUrl);
  }
  getListLoansxIdClient(idClient : string): Observable<any>{
    return this.http.get(this.BUrl + this.ApiUrl + idClient);
  }
  SaveLoans(loans: any): Observable<any>{
    return this.http.post(this.BUrl + this.ApiUrl, loans);
  }
  EditLoans(loans: any): Observable<any>{
    return this.http.put(this.BUrl + this.ApiUrl, loans);
  }
  DeleteLoans(id: number): Observable<any>{
    return this.http.delete(this.BUrl + this.ApiUrl + id);
  }
}
