import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { WebService } from 'src/app/services/web.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-add-books',
  templateUrl: './add-books.component.html',
  styleUrls: ['./add-books.component.css']
})
export class AddBooksComponent implements OnInit {

  model: any = {};
  addForm: FormGroup;
  @Output() cancelAddBook = new EventEmitter();

  constructor(private fb: FormBuilder, private route: Router, private webService: WebService,
              private alertify: AlertifyService) {
    this.addForm = this.fb.group({
      title: ['', [Validators.required]],
    });
  }

  ngOnInit() {
  }

  addBook() {
    this.webService.addBook(this.model).subscribe(() => {
      this.alertify.success('Added successfully');
    }, error => {
      this.alertify.error(error);
    });
    console.log(this.model);
  }

  back() {
    this.cancelAddBook.emit(false);
  }
}
