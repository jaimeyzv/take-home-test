import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoanService } from '../../services/loan.service';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-loan-pay',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
  ],
  templateUrl: './loan-pay.component.html',
  styleUrl: './loan-pay.component.scss',
})
export class LoanPayComponent implements OnInit {
  loanForm!: FormGroup;
  loanId!: number;
  payAmount!: number;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private loanService: LoanService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loanId = Number(this.route.snapshot.paramMap.get('loanId'));
    this.loanForm = this.fb.group({
      payAmount: [null, Validators.required],
    });
  }

  goBack() {
    this.router.navigate(['/loans']);
  }

  onSubmit(): void {
    if (this.loanForm.valid) {
      this.loanService
        .payLoan(this.loanId, this.loanForm.value.payAmount)
        .subscribe({
          next: () => this.router.navigate(['/loans']),
          error: (err) => console.error('Error paying loan:', err),
        });
    }
  }
}
