import { Routes } from '@angular/router';
import { LoanListComponent } from './features/loans/components/loan-list/loan-list.component';
import { LoanCreateComponent } from './features/loans/components/loan-create/loan-create.component';

export const routes: Routes = [
  {
    path: 'loans',
    children: [
      { path: '', component: LoanListComponent },
      { path: 'create', component: LoanCreateComponent },
    ],
  },
  { path: '', redirectTo: 'loans', pathMatch: 'full' },
];
