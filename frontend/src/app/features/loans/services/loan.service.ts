import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoanList } from '../models/loan-list.model';

@Injectable({
  providedIn: 'root',
})
export class LoanService {
  private baseUrl = 'https://localhost:52252/loans/';
  constructor(private http: HttpClient) {}

  getLoans(): Observable<{ loans: LoanList[] }> {
    return this.http.get<{ loans: LoanList[] }>(this.baseUrl);
  }

  createLoan(loan: Omit<LoanList, 'loanId'>): Observable<LoanList> {
    return this.http.post<LoanList>(this.baseUrl, loan);
  }
}
