import React from "react";
import "./index.css";
import { useEffect, useState } from "react";
import firebase from "firebase";
import "firebase/auth";
import { COMMENTS_API_URL } from "../../../../constants";

export default function CommentBox({ eventId }) {
  const [userData, setUserData] = useState();
  const [commentData, setCommentData] = useState();

  useEffect(() => {
    firebase.auth().onAuthStateChanged((user) => {
      setUserData(() => user);
    });
  }, []);

  useEffect(() => {
    async function fetchData() {
      const data = await fetch(
        `${COMMENTS_API_URL}/comments?eventid=${eventId}`
      );
      const json = await data.json();
      setCommentData(() => json);
    }
    fetchData();
  }, []);

  async function submitComment() {
    var token = await firebase.auth().currentUser.getIdToken(true);
    await fetch(`${COMMENTS_API_URL}/comments`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      body: JSON.stringify({
        eventId: 1,
        content: "asd",
      }),
    });
  }

  return (
    <div className="comments-container">
      {commentData &&
        commentData.length > 0 &&
        commentData.map((comment) => (
          <div key={comment.id} className="comment-entry">
            <h1>{`${comment.userName}`}</h1>
            <h1>{`${comment.content}`}</h1>
          </div>
        ))}
      {userData ? (
        <div className="submit-comment">
          <textarea rows={2} placeholder="Type comment here"></textarea>
          <button onClick={() => submitComment()}>Add</button>
        </div>
      ) : null}
    </div>
  );
}
