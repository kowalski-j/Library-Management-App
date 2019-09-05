import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../services/web.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private router: Router, private webService: WebService) { }

  ngOnInit() {
  }

  book() {
    this.router.navigate(['/book']);
  }

  category() {
    this.router.navigate(['/category']);
  }

}
