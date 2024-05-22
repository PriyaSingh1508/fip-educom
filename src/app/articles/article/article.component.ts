import { Component } from '@angular/core';
import { ArticleService } from '../article.service';
import { Article, TutorialItem } from 'src/app/model';
import { ArticleCategoryItem } from 'src/app/model';
import { TutorialCategory } from 'src/app/model';
@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent {
  constructor(private articleService:ArticleService){}
 
 tutorial: TutorialCategory = {
    name: "HTML",
    image: "../../../assets/images/trending_categories.svg",
    item: []
  };
  ngOnInit(): void {
    this.getArticleTypes();
   
    
  }
  getArticleTypes():void{
    this.articleService.getData<TutorialCategory>("article-type.json").subscribe((data)=>{this.tutorial=data;})
  }
 

 
  selectedArticle:TutorialItem={
       "categoryId":1,
				"itemId":1,
				"heading":"Data Structure",
				"text":"XOR Linked List – A Memory Efficient Doubly Linked List"
 }
  renderArticles(event:any){
       this.articleService.getData<TutorialItem[]>("articles-category.json").subscribe((data)=>{this.selectedArticle=data.find(item => item.itemId === event.itemId && item.categoryId === event.categoryId)||this.selectedArticle;});
  }


  
}
