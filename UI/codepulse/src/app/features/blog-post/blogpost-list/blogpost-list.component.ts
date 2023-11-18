import { Component, OnInit } from '@angular/core';
import { BlogPostService } from '../services/blog-post.service';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/blog-post.model';

@Component({
  selector: 'app-blogpost-list',
  templateUrl: './blogpost-list.component.html',
  styleUrls: ['./blogpost-list.component.css']
})
export class BlogpostListComponent implements OnInit {

blogPosts?: Observable<BlogPost[]>;
constructor(private BlogPostSevice: BlogPostService){

}

  ngOnInit(): void {
    // get all blog post from api
    this.blogPosts = this.BlogPostSevice.getAllBlogPosts();
  }

}
