import { Injectable } from "@angular/core";
import { HttpService } from "./httpService";
import { CommentListingModel } from "../../models/CommentListingModel";
import { AddCommentModel } from "../../models/AddCommentModel";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root',
})

export class CommentsService {
  constructor(private http: HttpService, private httpClient: HttpClient) { }

  async getAllCommentsByGameAlias(gameAlias: string) {
    return await this.http.get<CommentListingModel[]>(`comments/${gameAlias}`);
  }

  async addComment(comment: AddCommentModel) {
    return await this.http.post<AddCommentModel>(`comments`, comment);
  }

  addComment2(comment: AddCommentModel): Observable<AddCommentModel> {
    return this.httpClient.post<AddCommentModel>('comments', comment, { withCredentials: true });
  }

  async deleteComment(commentId: number) {
    return await this.http.delete<string>(`comments/${commentId}`);
  }
}
