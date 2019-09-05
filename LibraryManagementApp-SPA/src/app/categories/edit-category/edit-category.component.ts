import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { WebService } from 'src/app/services/web.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit {
  model: any;
  addForm: FormGroup;
  @Output() cancelEditcategory = new EventEmitter();
  @Input() modelsFromCategory: any;

  constructor(private fb: FormBuilder, private route: Router, private webService: WebService,
              private alertify: AlertifyService) {
    this.addForm = this.fb.group({
      title: ['', [Validators.required]],
    });
  }

  ngOnInit() {
  }

  updateCategory() {
this.webService.editCategory(this.model).subscribe(() => {
  this.alertify.success('Updated successfully');
}, error => {
  this.alertify.error(error);
});
  }

  back() {
    this.cancelEditcategory.emit(false);
  }
}
