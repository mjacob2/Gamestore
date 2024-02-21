import { Component, Inject } from '@angular/core';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { CommentsService } from '../../../services/commentsService';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { AddCommentModel } from '../../../../models/AddCommentModel';
import { CommentListingModel, CommentType } from '../../../../models/CommentListingModel';

@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.css']
})
export class AddCommentComponent {

  isLoading: boolean = false;
  errorMessage: string = '';
  gameAlias: string = '';
  comment?: CommentListingModel;
  commentType?: CommentType;
  quotedBody?: string;

  constructor(
    private bottomSheetRef: MatBottomSheetRef<AddCommentComponent>,
    private httpService: CommentsService,
    private route: ActivatedRoute,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: any,
  ) { this.gameAlias = data.gameAlias, this.comment = data.comment, this.commentType = data.commentType }

  ngOnInit() {
    console.log(this.gameAlias);
    console.log(this.commentType);


    if (this.commentType == CommentType.quote) {
      this.quotedBody = this.comment?.body;
      console.log("comment as quote!")
    }
  }

  async onSubmit(form: NgForm) {

    if (!form.valid) {
      this.errorMessage = "Fields marked red are obligatory"
    } else {
      this.errorMessage = ""
      this.isLoading = true;
      var commentToAdd: AddCommentModel = form.value;
      commentToAdd.gameAlias = this.gameAlias;

      if (this.commentType == CommentType.reply) {
        commentToAdd.asReplyTo = this.comment?.id;
        console.log("comment as reply!")
      }

      if (this.commentType == CommentType.quote) {
        commentToAdd.asQuoteTo = this.comment?.id;
        console.log("comment as quote!")
      }


      console.log(commentToAdd)

      try {
        await this.httpService.addComment(commentToAdd);
        this.bottomSheetRef.dismiss({ event: 'commentAddedSuccesfully' });
        this.isLoading = false;
      } catch (error: any) {
        this.isLoading = false;
        this.errorMessage = error.message;
      }
    }
  }

  closeBottomSheet(): void {
    this.bottomSheetRef.dismiss();
  }
}
