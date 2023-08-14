import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AddHallComponent } from './components/add-hall/add-hall.component';
import { SearchHallComponent } from './components/search-hall/search-hall.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { WeddingAdviceComponent } from './components/wedding-advice/wedding-advice.component';
import { CommentComponent } from './components/comment/comment.component';
 import { UserAccountComponent } from './components/user-account/user-account.component';
 

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'add-hall', component: AddHallComponent },
  { path: 'search-hall', component: SearchHallComponent },
  { path: 'wedding-advice', component: WeddingAdviceComponent },
   { path: 'user-account', component: UserAccountComponent },
  { path: 'comment', component: CommentComponent },

  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
