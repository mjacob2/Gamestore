import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GamesTableComponent } from './components/games/games-table/games-table.component';

import { MatTableModule } from '@angular/material/table';
import { AddGameComponent } from './components/games/add-game/add-game.component';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatInputModule } from '@angular/material/input';
import { ErrorCardComponent } from './components/shared/error-card/error-card.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { GameDetailsComponent } from './components/games/game-details/game-details.component';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { HttpClientModule } from '@angular/common/http';
import { PublishersTableComponent } from './components/publishers/publishers-table/publishers-table.component';
import { AddPublisherComponent } from './components/publishers/add-publisher/add-publisher.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { TableComponent } from './components/shared/table/table.component';
import { PublisherDetailsComponent } from './components/publishers/publisher-details/publisher-details.component';
import { AddPlatformComponent } from './components/platforms/add-platform/add-platform.component';
import { AddGenreComponent } from './components/genres/add-genre/add-genre.component';
import { CurrentOrderComponent } from './components/orders/current-order/current-order.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatMenuModule } from '@angular/material/menu';
import { OrdersTableComponent } from './components/orders/orders-table/orders-table.component';
import { OrderDetailsComponent } from './components/orders/order-details/order-details.component';
import { MakeOrderComponent } from './components/orders/make-order/make-order.component';
import { CommentsListingComponent } from './components/comments/comments-listing/comments-listing.component';
import { AddCommentComponent } from './components/comments/add-comment/add-comment.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSliderModule } from '@angular/material/slider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatPaginatorModule } from '@angular/material/paginator';
import { OrdersHistoryComponent } from './components/orders/orders-history/orders-history.component';
import { FilteringOptionsComponent } from './components/shared/filtering-options/filtering-options.component';

const appRoutes: Routes = [
  { path: '', component: GamesTableComponent },
  { path: 'games', component: GamesTableComponent },
  { path: 'games/:gameAlias', component: GameDetailsComponent },
  { path: 'games/:gameAlias/comments', component: CommentsListingComponent },
  { path: 'publishers', component: PublishersTableComponent },
  { path: 'publishers/:publisherId', component: PublisherDetailsComponent },
  { path: 'cart', component: CurrentOrderComponent },
  { path: 'orders', component: OrdersTableComponent },
  { path: 'orders/history', component: OrdersHistoryComponent },
  { path: 'orders/:orderId', component: OrderDetailsComponent },
  { path: 'makeOrder', component: MakeOrderComponent },

];

@NgModule({
  declarations: [
    AppComponent,
    GamesTableComponent,
    AddGameComponent,
    ErrorCardComponent,
    GameDetailsComponent,
    PublishersTableComponent,
    AddPublisherComponent,
    TableComponent,
    PublisherDetailsComponent,
    AddPlatformComponent,
    AddGenreComponent,
    CurrentOrderComponent,
    OrdersTableComponent,
    OrderDetailsComponent,
    MakeOrderComponent,
    CommentsListingComponent,
    AddCommentComponent,
    OrdersHistoryComponent,
    FilteringOptionsComponent
  ],
  imports: [
    HttpClientModule,
    RouterModule.forRoot(appRoutes, { anchorScrolling: 'enabled' }),
    BrowserModule,
    BrowserAnimationsModule, MatTableModule, MatBottomSheetModule, MatIconModule, MatButtonModule,
    MatFormFieldModule, FormsModule, ReactiveFormsModule, MatProgressSpinnerModule,
    MatSelectModule, MatProgressBarModule, MatCardModule, MatInputModule, MatCheckboxModule, MatCardModule,
    MatListModule, MatToolbarModule, MatSnackBarModule, MatMenuModule, MatDatepickerModule, MatSliderModule,
    MatNativeDateModule, MatExpansionModule, MatPaginatorModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
