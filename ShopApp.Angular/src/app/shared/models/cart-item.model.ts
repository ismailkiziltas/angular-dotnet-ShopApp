export interface CartItem {
    id: number;
    productId: number;
    quantity: number;
    product: {
        name: string;
        price: number;
        imageUrl: string;
    };
}