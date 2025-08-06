import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { LoanService } from '../../services/loan.service';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-loan-create',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
  ],
  templateUrl: './loan-create.component.html',
  styleUrl: './loan-create.component.scss',
})
export class LoanCreateComponent implements OnInit {
  loanForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private loanService: LoanService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loanForm = this.fb.group({
      amount: [null, Validators.required],
      applicantName: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.loanForm.valid) {
      this.loanService.createLoan(this.loanForm.value).subscribe({
        next: () => this.router.navigate(['/loans']),
        error: (err) => console.error('Error creating loan:', err),
      });
    }
  }
}
