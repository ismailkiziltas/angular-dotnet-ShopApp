export interface OrderItem {
    productId: number;
    quantity: number;
    unitPrice: number;
    product: {
        name: string;
    };
}

export interface Order {
    id: number;
    orderDate: string;
    totalPrice: number;
    status: number;
    address: string;
    orderItems: OrderItem[];
}