import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Loan } from '../models/loan.model';

@Injectable({
  providedIn: 'root',
})
export class LoanService {
  private baseUrl = 'https://localhost:52252/loans/';
  constructor(private http: HttpClient) {}

  getLoans(): Observable<{ loans: Loan[] }> {
    return this.http.get<{ loans: Loan[] }>(this.baseUrl);
  }
}
