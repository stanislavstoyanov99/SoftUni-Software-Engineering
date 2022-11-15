import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api-service';
import { IPost } from '../models/IPost';

@Component({
  selector: 'app-recent-posts',
  templateUrl: './recent-posts.component.html',
  styleUrls: ['./recent-posts.component.scss']
})
export class RecentPostsComponent implements OnInit {

  recentPosts: IPost[] = [];
  errorFetcingData = false;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.loadPosts(5).subscribe({
      next: (data) => {
        this.recentPosts = data;
      },
      error: (error) => {
        this.errorFetcingData = true;
        console.log(error);
      }
    });
  }

}
