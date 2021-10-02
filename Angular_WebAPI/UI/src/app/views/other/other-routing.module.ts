import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InvoiceComponent } from './invoice.component';
import { TransactionComponent } from './transaction.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'colors'
    },
    children: [
      {
        path: '',
        redirectTo: 'colors'
      },
      {
        path: 'invoice',
        component: InvoiceComponent,
        data: {
          title: 'Invoice'
        }
      },
      {
        path: 'transaction',
        component: TransactionComponent,
        data: {
          title: 'Transaction'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OtherRoutingModule {}
