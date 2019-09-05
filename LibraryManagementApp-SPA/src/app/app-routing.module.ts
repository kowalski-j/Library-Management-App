import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BookComponent } from './books/book/book.component';
import { CategoryComponent } from './categories/category/category.component';
import { AddCategoryComponent } from './categories/add-category/add-category.component';
import { EditCategoryComponent } from './categories/edit-category/edit-category.component';
import { EditBooksComponent } from './books/edit-books/edit-books.component';
import { AddBooksComponent } from './books/add-books/add-books.component';


const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'book', component: BookComponent },
  { path: 'add-book', component: AddBooksComponent },
  { path: 'edit-book', component: EditBooksComponent },
  { path: 'category', component: CategoryComponent },
  { path: 'add-category', component: AddCategoryComponent },
  { path: 'edit-category', component: EditCategoryComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
