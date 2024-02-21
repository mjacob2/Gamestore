import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DownloadService {
  baseUrl: string = 'http://localhost:5102/';

  constructor(private http: HttpClient) { }

  downloadGame(gameAlias: string): Observable<Blob> {
    const url = `${this.baseUrl}games/${gameAlias}/download`;
    return this.http.get(url, { responseType: 'blob' });
  }

  buyByBankAndDownloadInvoice(): Observable<Blob> {
    const url = `${this.baseUrl}orders/pay/bank`;
    return this.http.get(url, { responseType: 'blob' });
  }
}
