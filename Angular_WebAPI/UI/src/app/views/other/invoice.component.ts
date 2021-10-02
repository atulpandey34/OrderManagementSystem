import { Component, Inject, OnInit } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { getStyle, rgbToHex } from '@coreui/coreui/dist/js/coreui-utilities';

@Component({
  templateUrl: 'invoice.component.html'
})
export class InvoiceComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {
   // this.themeColors();
  }
}
