import { Component } from '@angular/core';
import { LoanService } from '../../services/loan.service';
import { Loan } from '../../models/loan.model';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-loan-list',
  imports: [CommonModule, MatTableModule, MatButtonModule],
  templateUrl: './loan-list.component.html',
  styleUrls: ['./loan-list.component.scss'],
})
export class LoanListComponent {
  loans: Loan[] = [];
  displayedColumns: string[] = [
    'loanAmount',
    'currentBalance',
    'applicant',
    'status',
  ];

  constructor(private loanService: LoanService) {}

  ngOnInit(): void {
    this.loanService.getLoans().subscribe({
      next: (data) => (this.loans = data.loans),
      error: (err) => console.error('Error fetching loans:', err),
    });
  }
}
