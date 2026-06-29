import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgIf, CurrencyPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../../core/services/product';
import { CartService } from '../../../core/services/cart';
import { Product } from '../../../shared/models/product.model';

@Component({
  selector: 'app-product-detail',
  imports: [NgIf, FormsModule, CurrencyPipe],
  templateUrl: './product-detail.html',
  styleUrl: './product-detail.scss'
})
export class ProductDetail implements OnInit {
  product: Product | null = null;
  quantity = 1;
  errorMessage = '';

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private cartService: CartService,
    private router: Router,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.productService.getById(id).subscribe(data => {
      this.product = data;
      this.cdr.detectChanges();
    });
  }

  addToCart(): void {
    if (this.product) {
      if (this.quantity < 1) {
        this.errorMessage = 'Adet en az 1 olmalıdır.';
        return;
      }
      if (this.quantity > this.product.stock) {
        this.errorMessage = `Stokta yalnızca ${this.product.stock} adet bulunmaktadır.`;
        return;
      }
      this.errorMessage = '';
      this.cartService.addToCart(this.product.id, this.quantity).subscribe({
        next: () => {
          this.router.navigate(['/cart']);
        },
        error: (err) => {
          if (err.status === 401) {
            alert('Sepete eklemek için giriş yapmanız gerekiyor!');
            this.router.navigate(['/login']);
          } else {
            this.errorMessage = 'Bir hata oluştu, lütfen tekrar deneyin.';
          }
        }
      });
    }
  }
}