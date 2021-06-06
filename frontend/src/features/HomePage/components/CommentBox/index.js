import React from "react";
import "./index.css";
import { useEffect, useState } from "react";
import firebase from "firebase";
import "firebase/auth";
import { COMMENTS_API_URL } from "../../../../constants";

async function fetchData(eventId, onSuccess) {
  const data = await fetch(`${COMMENTS_API_URL}/comments?eventId=${eventId}`);
  const json = await data.json();
  onSuccess(() => json);
}

export default function CommentBox({ eventId }) {
  const [userData, setUserData] = useState();
  const [commentData, setCommentData] = useState();
  const [commentText, setCommentText] = useState();

  useEffect(() => {
    firebase.auth().onAuthStateChanged((user) => {
      setUserData(() => user);
    });
  }, []);

  useEffect(() => {
    fetchData(eventId, setCommentData);
  }, []);

  async function submitComment() {
    const token = await firebase.auth().currentUser.getIdToken(true);
    fetch(`${COMMENTS_API_URL}/comments`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      body: JSON.stringify({
        eventId: eventId,
        content: commentText,
      }),
    }).then(() => fetchData(eventId, setCommentData));
  }

  return (
    <div className="comments-container">
      {commentData &&
        commentData.length > 0 &&
        commentData.slice(0, 3).map((comment) => (
          <div key={comment.id} className="comment-entry">
            <h1>{`${comment.userName} says:`}</h1>
            <h2>{`${comment.content}`}</h2>
          </div>
        ))}
      {userData ? (
        <div className="submit-comment">
          <textarea
            rows={2}
            placeholder="Type comment here"
            onChange={(e) => setCommentText(e.target.value)}
          ></textarea>
          <button onClick={() => submitComment()}>Add</button>
        </div>
      ) : null}
    </div>
  );
}
