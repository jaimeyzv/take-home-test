import { Component } from '@angular/core';
import { LoanService } from '../../services/loan.service';
import { LoanList } from '../../models/loan-list.model';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-loan-list',
  imports: [CommonModule, MatTableModule, MatButtonModule, RouterModule],
  templateUrl: './loan-list.component.html',
  styleUrls: ['./loan-list.component.scss'],
})
export class LoanListComponent {
  loans: LoanList[] = [];
  displayedColumns: string[] = [
    'loanAmount',
    'currentBalance',
    'applicant',
    'status',
    'actions',
  ];

  constructor(
    private loanService: LoanService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  goToCreate() {
    this.router.navigate(['/loans/create']);
  }

  goToPay(loanId: number) {
    this.router.navigate(['/loans/pay', loanId]);
  }

  ngOnInit(): void {
    this.loanService.getLoans().subscribe({
      next: (data) => (this.loans = data.loans),
      error: (err) => console.error('Error fetching loans:', err),
    });
  }
}
