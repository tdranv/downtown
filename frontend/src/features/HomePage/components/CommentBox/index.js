import React from "react";
import { useEffect, useState } from "react";
import firebase from "firebase";
import "firebase/auth";

export default function CommentBox(event) {
  const [userData, setUserData] = useState();
  const [commentData, setCommentData] = useState();

  useEffect(() => {
    firebase.auth().onAuthStateChanged((user) => {
      setUserData(() => user);
    });
  }, []);

  useEffect(() => {
    async function fetchData() {
      const data = await fetch(`https://localhost:44316/comments?eventid=${1}`);
      const json = await data.json();
      setCommentData(data);
    }
    fetchData();
  }, []);

  console.log(userData);

  async function submitComment() {
    var token = await firebase.auth().currentUser.getIdToken(true);
    await fetch('https://localhost:44316/comments', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}` 
        },
        body: JSON.stringify({
            eventId: 1,
            content: 'asd'
        })}
    )}

  return (
    <div className="comment-box">
      {commentData &&
        commentData.length > 0 &&
        commentData.map((comment) => {
          <div key={comment.id}>
            <span>{comment.user}</span>:<span>{comment.text}</span>
          </div>;
        })}

      {userData ? (
        <div>
          <textarea placeholder="Type comment here"></textarea>
          <button onClick={() => submitComment()}>Add</button>
        </div>
      ) : null}
    </div>
  );
}
