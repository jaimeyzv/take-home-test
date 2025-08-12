import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoanHistory } from '../models/loan-history.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoanHistoryService {
  private baseUrl = 'https://localhost:52252/api/loans/history/';
  constructor(private http: HttpClient) {}

  history(loanId: number): Observable<any> {
    const url = `${this.baseUrl}${loanId}`;
    return this.http.get<{ loans: LoanHistory[] }>(url);
  }
}
