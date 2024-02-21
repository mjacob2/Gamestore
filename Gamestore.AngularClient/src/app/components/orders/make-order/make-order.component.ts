import { Component } from '@angular/core';
import { DownloadService } from '../../../services/downloadService';
import { OrdersService } from '../../../services/ordersService';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
    selector: 'app-make-order',
    templateUrl: './make-order.component.html',
    styleUrls: ['./make-order.component.css']
})
export class MakeOrderComponent {
    errorMessage: string = '';
    isLoading: boolean = false;

    constructor(
        private downloadService: DownloadService,
        private ordersService: OrdersService,
        private snackBar: MatSnackBar,
        private router: Router
    ) { }

    payWithBank() {
        this.isLoading = true;
        this.downloadService.buyByBankAndDownloadInvoice().subscribe({
            next: data => {
                const blob = new Blob([data], { type: 'text/plain' });
                const url = window.URL.createObjectURL(blob);
                var link = document.createElement('a');
                link.href = url;
                link.download = `invoice.pdf`;
                link.click();
                this.isLoading = false;
                this.snackBar.open(
                    'Order paid succesfully',
                    'Close',
                    {
                        duration: 5000,
                        horizontalPosition: 'center',
                        verticalPosition: 'bottom',
                    });
                this.router.navigate(['/orders/']);
            },
            error: err => {
                this.isLoading = false;
                this.errorMessage = err;
            }
        });
    }

    async payWithIBox() {
        this.isLoading = true;
        try {
            await this.ordersService.payForOrderIbox();
            this.isLoading = false;
            this.snackBar.open(
                'Order paid succesfully',
                'Close',
                {
                    duration: 5000,
                    horizontalPosition: 'center',
                    verticalPosition: 'bottom',
                });
            this.router.navigate(['/orders/']);
        } catch (error: any) {
            this.isLoading = false;
            this.errorMessage = error;
        }
    }

    async payWithVisa() {
        this.isLoading = true;
        try {
            await this.ordersService.payForOrderVisa();
            this.isLoading = false;
            this.snackBar.open(
                'Order paid succesfully',
                'Close',
                {
                    duration: 5000,
                    horizontalPosition: 'center',
                    verticalPosition: 'bottom',
                });
            this.router.navigate(['/orders/']);
        } catch (error: any) {
            this.isLoading = false;
            this.errorMessage = error;
        }
    }
}
