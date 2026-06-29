import { Routes } from '@angular/router';
import { Login } from './features/auth/login/login';
import { Register } from './features/auth/register/register';
import { ProductList } from './features/products/product-list/product-list';
import { ProductDetail } from './features/products/product-detail/product-detail';
import { Cart } from './features/cart/cart/cart';
import { OrderList } from './features/orders/order-list/order-list';
import { authGuard } from './core/guards/auth-guard';


export const routes: Routes = [
    { path: '', redirectTo: 'products', pathMatch: 'full' },
    { path: 'login', component: Login },
    { path: 'register', component: Register },
    { path: 'cart', component: Cart, canActivate: [authGuard] },
    { path: 'products', component: ProductList },
    { path: 'products/:id', component: ProductDetail },
    { path: 'orders', component: OrderList, canActivate: [authGuard] }
];
