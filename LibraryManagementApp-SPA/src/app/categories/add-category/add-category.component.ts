import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { WebService } from 'src/app/services/web.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  model: any = {};
  addForm: FormGroup;
  @Output() cancelAddCategory = new EventEmitter();

  constructor(private fb: FormBuilder, private route: Router, private webService: WebService,
              private alertify: AlertifyService) {
    this.addForm = this.fb.group({
      title: ['', [Validators.required]],
    });
  }

  ngOnInit() {
  }

  addCategory() {
    this.webService.addCategory(this.model).subscribe(() => {
      this.alertify.success('Added successfully');
    }, error => {
      this.alertify.error(error);
    });
    console.log(this.model);
  }

  back() {
    this.cancelAddCategory.emit(false);
  }
}
