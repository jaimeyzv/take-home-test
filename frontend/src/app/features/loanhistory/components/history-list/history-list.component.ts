import { Component } from '@angular/core';
import { LoanHistory } from '../models/loan-history.model';
import { LoanHistoryService } from '../services/loan-history.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-history-list',
  imports: [CommonModule],
  templateUrl: './history-list.component.html',
  styleUrl: './history-list.component.scss',
})
export class HistoryListComponent {
  history: LoanHistory[] = [];
  loanId!: number;

  constructor(
    private loanHistoryService: LoanHistoryService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loanId = Number(this.route.snapshot.paramMap.get('loanId'));
    this.loanHistoryService.history(this.loanId).subscribe({
      next: (data) => (this.history = data.history),
      error: (err) => console.error('Error fetching loans:', err),
    });
  }

  goBack() {
    this.router.navigate(['/loans']);
  }
}
