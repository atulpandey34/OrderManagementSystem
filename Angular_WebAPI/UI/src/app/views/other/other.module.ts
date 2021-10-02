// Angular
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { InvoiceComponent } from './invoice.component';
import { TransactionComponent } from './transaction.component';

// Other Routing
import { OtherRoutingModule } from './other-routing.module';

@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    OtherRoutingModule
  ],
  declarations: [
    InvoiceComponent,
    TransactionComponent
  ]
})
export class OtherModule { }
