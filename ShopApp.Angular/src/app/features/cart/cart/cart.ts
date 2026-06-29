import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { NgFor, NgIf, CurrencyPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CartService } from '../../../core/services/cart';
import { OrderService } from '../../../core/services/order';
import { CartItem } from '../../../shared/models/cart-item.model';

@Component({
  selector: 'app-cart',
  imports: [NgFor, NgIf, CurrencyPipe, FormsModule],
  templateUrl: './cart.html',
  styleUrl: './cart.scss'
})
export class Cart implements OnInit {
  cartItems: CartItem[] = [];
  address = '';

  constructor(
    private cartService: CartService,
    private orderService: OrderService,
    private router: Router,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadCart();
  }

  loadCart(): void {
    this.cartService.getCart().subscribe(data => {
      this.cartItems = data;
      this.cdr.detectChanges();
    });
  }

  get totalPrice(): number {
    return this.cartItems.reduce((sum, item) =>
      sum + item.product.price * item.quantity, 0);
  }

  removeItem(id: number): void {
    this.cartService.removeFromCart(id).subscribe(() => {
      this.loadCart();
    });
  }

  placeOrder(): void {
    this.orderService.createOrder(this.address).subscribe(() => {
      this.router.navigate(['/orders']);
    });
  }
}