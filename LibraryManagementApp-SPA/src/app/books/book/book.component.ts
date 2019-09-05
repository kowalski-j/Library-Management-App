import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from 'src/app/services/web.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  model: any = [];
  headElements = ['id', 'Name', '', ''];


  constructor(private router: Router, private webService: WebService) { }
  editBookMode = false;
  addBookMode = false;
  bookMode = true;
  ngOnInit() {
  }


  getBooks() {
    this.webService.getBooks().subscribe((res: any[]) => {
      console.log(res);
      this.model = res;
    }, error => {
      console.log(error);
    });
  }

  deleteBooks(id: number) {
    this.webService.deleteBooks(id).subscribe(() => {
      console.log('deleted');
    }, error => {
      console.log(error);
    });
  }

  editBookToggle() {
    this.editBookMode = true;
    this.bookMode = false;
  }
  addBookToggle() {
    this.addBookMode = true;
    this.bookMode = false;
  }
  cancelAddBookMode(addBookMode: boolean) {
    this.addBookMode = addBookMode;
    this.bookMode = true;
  }
  cancelEditBookMode(editBookMode: boolean) {
    this.editBookMode = editBookMode;
    this.bookMode = true;
  }
}
