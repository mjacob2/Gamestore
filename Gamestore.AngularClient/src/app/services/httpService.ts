import { Injectable } from '@angular/core';

interface ApiResponse<T> {
  data: T;
  totalCount?: number;
}

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  baseUrl: string = 'http://localhost:5102/';

  totalGamesCount: number = 0;
  totalGamesCountFromHeader: number = 0;
  totalPages?: number;
  hasNextPage?: boolean;
  hasPreviousPage?: boolean;

  public async sendRequest<T>(method: string, url: string, body?: any): Promise<T> {
    let response;
    try {
      response = await fetch(`${this.baseUrl}${url}`, this.prepareRequest(method, url, body));

      let gamesCountFromHeader = response.headers.get('X-Games-Count');
      if (gamesCountFromHeader !== null) {
        let gamesCountNumber = parseInt(gamesCountFromHeader, 10);
        this.totalGamesCountFromHeader = gamesCountNumber;
      }

    } catch (error) {
      throw new Error('The server is unreachable or offline');
    }

    if (!response.ok) {
      await this.handleErrors(response);
    }

    const responseData: ApiResponse<T> = await response.json();

    if (responseData.totalCount) {
      this.totalGamesCount = responseData.totalCount;
    }

    return responseData.data;
  }

  async get<T>(url: string): Promise<T> {
    return this.sendRequest<T>('GET', url);
  }

  async post<T>(url: string, body?: any): Promise<T> {
    return this.sendRequest<T>('POST', url, body);
  }

  async put<T>(url: string, body?: any): Promise<T> {
    return this.sendRequest<T>('PUT', url, body);
  }

  async patch<T>(url: string, body: any): Promise<T> {
    return this.sendRequest<T>('PATCH', url, body);
  }

  async delete<T>(url: string, body?: any): Promise<T> {
    return this.sendRequest<T>('DELETE', url, body);
  }

  private prepareRequest(method: string, url: string, body?: any) {
    let request = {
      method: method,
      body: body ? JSON.stringify(body) : undefined,
      headers: this.getHeaders(),
      credentials: 'include' as RequestCredentials,
    };
    return request;
  }

  private getHeaders() {
    let authHeader: string = 'Basic';
    let headers = {
      'Content-Type': 'application/json',
      'Authorization': authHeader
    };
    return headers;
  }

  private async handleErrors(response: Response): Promise<any> {
    let responseData = await response.json();
    let errorMessage = '';

    if (responseData.errors) {
      errorMessage = this.processErrors(responseData.errors);
    }
    else if (responseData.Detail) {
      errorMessage = responseData.Detail;
    }
    else {
      errorMessage = 'An unknown error occurred';
    }

    throw new Error(errorMessage);
  }

  private processErrors(errors: { [x: string]: any; }): string {
    let errorKeys = Object.keys(errors);

    if (errorKeys.length > 0) {
      let firstKey = errorKeys[0];
      let firstError = errors[firstKey];

      if (firstError && Array.isArray(firstError)) {
        return firstError[0];
      }
    }
    return JSON.stringify(errors);
  }
}
