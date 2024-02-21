import { Component } from '@angular/core';
import { CommentsService } from '../../../services/commentsService';
import { ActivatedRoute, Params } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommentListingModel, CommentType } from '../../../../models/CommentListingModel';
import { MatBottomSheet, MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { AddCommentComponent } from '../add-comment/add-comment.component';
import { ViewportScroller } from '@angular/common';

@Component({
  selector: 'app-comments-listing',
  templateUrl: './comments-listing.component.html',
  styleUrls: ['./comments-listing.component.css']
})
export class CommentsListingComponent {

  errorMessage: string = '';
  isLoading: boolean = false;
  gameAlias: string = '';
  comments: CommentListingModel[] = [];
  public commentType = CommentType;
  constructor(
    private httpService: CommentsService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    private viewportScroller: ViewportScroller

  ) { }


  async ngOnInit() {
    this.isLoading = true;
    this.route.params.subscribe(async (params: Params) => {
      this.gameAlias = params['gameAlias'];
    });
    await this.getComments();
  }

  openAddCommentBottomSheet(comment?: CommentListingModel, commentType?: CommentType) {
    const addGameBottomSheet: MatBottomSheetRef = this.bottomSheet.open(
      AddCommentComponent,
      {
        data: {
          gameAlias: this.gameAlias,
          comment: comment,
          commentType: commentType,
        },
        disableClose: true,
      }
    );

    addGameBottomSheet.afterDismissed().subscribe(async (result) => {
      if (result?.event === "commentAddedSuccesfully") {
        await this.getComments();
      }
    });
  }

  getComment(id: number): CommentListingModel | undefined {
    const comment = this.comments.find(comment => comment.id === id);
    return comment;
  }

  getCommentIdAsString(number: number): string {
    const comment = this.comments.find(comment => comment.id === number);
    console.log(comment);
    if (comment != undefined) {
      return comment.id.toString();
    } else {
      return "";
    }
  }

  public scrollTo(elementId: string): void {
    this.viewportScroller.scrollToAnchor(elementId);
  }

  async deleteComment(commentId: number) {
    this.isLoading = true;
    await this.httpService
      .deleteComment(commentId)
      .then(async response => {
        this.isLoading = false;
        this.snackBar.open(
          response,
          'Close',
          {
            duration: 3000,
          });
        await this.getComments();
      })
      .catch(error => {
        this.isLoading = false;
        this.errorMessage = error.message;
      });
  }

    private async getComments(): Promise<void> {
    await this.httpService
      .getAllCommentsByGameAlias(this.gameAlias)
      .then(comments => {
        console.log(comments)
        this.comments = comments;
        this.isLoading = false;
      })
      .catch(error => {
        this.isLoading = false;
        this.errorMessage = error.message;
      });
  }
}
