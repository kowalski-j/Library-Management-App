import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from 'src/app/services/web.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  model: any = [];

  headElements = ['No', 'Name', '', ''];

  constructor(private router: Router, private webService: WebService) { }
  editCategoryMode = false;
  addCategoryMode = false;
  categoryMode = true;
  ngOnInit() {
  }


  getCategories() {
    this.webService.getCategories().subscribe((res: any[]) => {
      console.log(res);
      this.model = res;
    }, error => {
      console.log(error);
    });
  }

  deleteCategories(id: number) {
    this.webService.deleteCategories(id).subscribe(() => {
      console.log('deleted');
    }, error => {
      console.log(error);
    });
  }

  editCategoryToggle() {
    this.editCategoryMode = true;
    this.categoryMode = false;
  }
  addCategoryToggle() {
    this.addCategoryMode = true;
    this.categoryMode = false;
  }
  cancelAddCategoryMode(addCategoryMode: boolean) {
    this.addCategoryMode = addCategoryMode;
    this.categoryMode = true;
  }
  cancelEditCategoryMode(editCategoryMode: boolean) {
    this.editCategoryMode = editCategoryMode;
    this.categoryMode = true;
  }
}
