import React from "react";
import Axios from "axios";

// let baseUrl = location.host.includes("localhost") ? "//localhost:5000/" : "/";

// let api = Axios.create({
//   baseURL: baseUrl + "api/",
//   timeout: 3000
// });

export default class Todos extends React.Component {
  state = {
    todos: []
  };
  componentDidMount() {
    //TODO finish learning this
    // Axios.get;
  }
  //TODO refactor for component usage
  render() {
    return (
      <div className="container">
        <div className="row d-flex">
          <div className="col-12">
            <h1 className="app-title">App Level</h1>
          </div>
          <div className="col-12">
            Add a task
            <input
              type="text"
              className="input-text"
              placeholder="Write a task"
              required
              value={this.state.newItem}
              onChange={e => this.updateInput(e.target.value)}
            ></input>
            <button
              className="add-btn btn-primary btn-sm m-1"
              onClick={() => this.addItem(this.state.newItem)}
              disabled={!this.state.newItem.length}
            >
              Add
            </button>
            <div className="col-12">
              <h4>Here is a list of the Todos:</h4>
            </div>
            <div className="list">
              <ul>
                {this.state.list.map(item => {
                  return (
                    <li className="border border-secondary" key={item.id}>
                      <input className="m-1" type="checkbox" />
                      Task: {item.value}&nbsp; | ID: {item.id}&nbsp; |
                      Status:&nbsp;
                      {item.isDone.toString()}
                      <button
                        className="btn btn-success m-1"
                        onClick={() => this.updateStatus(item.id)}
                      >
                        Change Status
                      </button>
                      <button
                        className="btn btn-danger m-1"
                        onClick={() => this.deleteItem(item.id)}
                      >
                        Delete
                      </button>
                    </li>
                  );
                })}
              </ul>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
