import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { NgFor, NgIf, CurrencyPipe, DatePipe } from '@angular/common';
import { OrderService } from '../../../core/services/order';
import { Order } from '../../../shared/models/order.model';

@Component({
  selector: 'app-order-list',
  imports: [NgFor, NgIf, CurrencyPipe, DatePipe],
  templateUrl: './order-list.html',
  styleUrl: './order-list.scss'
})
export class OrderList implements OnInit {
  orders: Order[] = [];

  constructor(
    private orderService: OrderService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    console.log('ngOnInit çalıştı');
    this.orderService.getMyOrders().subscribe(data => {
      this.orders = data;
      this.cdr.detectChanges();
    });
  }
}