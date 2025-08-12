import { Routes } from '@angular/router';
import { LoanListComponent } from './features/loans/components/loan-list/loan-list.component';
import { LoanCreateComponent } from './features/loans/components/loan-create/loan-create.component';
import { LoanPayComponent } from './features/loans/components/loan-pay/loan-pay.component';
import { HistoryListComponent } from './features/loanhistory/components/history-list/history-list.component';

export const routes: Routes = [
  {
    path: 'loans',
    children: [
      { path: '', component: LoanListComponent },
      { path: 'create', component: LoanCreateComponent },
      { path: 'pay/:loanId', component: LoanPayComponent },
      { path: 'history/:loanId', component: HistoryListComponent },
    ],
  },
  { path: '', redirectTo: 'loans', pathMatch: 'full' },
];
