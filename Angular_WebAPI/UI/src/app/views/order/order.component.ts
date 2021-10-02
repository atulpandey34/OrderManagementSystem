import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../services/order.service'
import { Order } from '../../model/Order'
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  templateUrl: 'order.component.html'
})
export class OrderComponent implements OnInit {
  closeResult = '';
  orderList: Order[];
  constructor(private orderservice: OrderService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.getAllOrdersOfUser();
  }

  getAllOrdersOfUser() {
    this.orderservice.GetOrdersList(1).subscribe((res) => {
      this.orderList = res;
    });
  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
