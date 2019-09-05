import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WebService {

  constructor(private http: HttpClient) { }

  addCategory(model: any) {
    return this.http.post('https://localhost:44341/api/category', model);
  }

  editCategory(model) {
    return this.http.put('https://localhost:44341/api/category/', model);
  }

  getCategories() {
    return this.http.get('https://localhost:44341/api/category');
  }

  getCategory(id: number) {
    return this.http.get('https://localhost:44341/api/category/' + id);

  }

  deleteCategories(id: number) {
    return this.http.delete('https://localhost:44341/api/category/' + id);
  }

  addBook(model: any) {
    return this.http.post('https://localhost:44341/api/book', model);
  }

  editBook(model: any) {
    return this.http.put('https://localhost:44341/api/book/', model);
  }

  getBooks() {
    return this.http.get('https://localhost:44341/api/book');
  }

  getBook(id: number) {
    return this.http.get('https://localhost:44341/api/book/' + id);

  }

  deleteBooks(id: number) {
    return this.http.delete('https://localhost:44341/api/book/' + id);
  }
}
