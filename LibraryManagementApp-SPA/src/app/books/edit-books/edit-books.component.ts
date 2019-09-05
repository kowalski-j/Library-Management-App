import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { WebService } from 'src/app/services/web.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-edit-books',
  templateUrl: './edit-books.component.html',
  styleUrls: ['./edit-books.component.css']
})
export class EditBooksComponent implements OnInit {
  model: any;

  addForm: FormGroup;
  @Output() cancelEditbook = new EventEmitter();
  @Input() modelsFromBook: any;

  constructor(private fb: FormBuilder, private route: Router, private webService: WebService,
              private alertify: AlertifyService) {
    this.addForm = this.fb.group({
      title: ['', [Validators.required]],
    });
  }

  ngOnInit() {
  }

  updateBook() {
    this.webService.editBook(this.model).subscribe(() => {
      this.alertify.success('Updated successfully');
    }, error => {
      this.alertify.error(error);
    });
  }

  back() {
    this.cancelEditbook.emit(false);
  }
}
