import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
// material
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule, matSelectAnimations } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatStepperModule } from '@angular/material/stepper';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatCardModule } from '@angular/material/card';



// components
import { AddHallComponent } from './components/add-hall/add-hall.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SearchHallComponent } from './components/search-hall/search-hall.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { WeddingAdviceComponent } from './components/wedding-advice/wedding-advice.component';
import { UserAccountComponent } from './components/user-account/user-account.component';
import { FooterComponent } from './components/footer/footer.component';
import { CommentComponent } from './components/comment/comment.component';






@NgModule({
  declarations: [
    AppComponent,
    AddHallComponent,
    HomeComponent,
    NavbarComponent,
    SearchHallComponent,
    NotFoundComponent,
    WeddingAdviceComponent,
    UserAccountComponent,
    FooterComponent,
    CommentComponent,
    
    
 
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    // material
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatCheckboxModule,
    MatSelectModule,
    MatToolbarModule,
    MatMenuModule,
    MatStepperModule,
    MatExpansionModule,
    MatCardModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
