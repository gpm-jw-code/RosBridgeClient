/*
© Siemens AG, 2019
Author: Sifan Ye (sifan.ye@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

namespace RosSharp.RosBridgeClient.Actionlib
{
    // This is defined according to actionlib_msgs/GoalStatus
    public enum ActionStatus
    {
        /// <summary>
        /// 这是内部服务器使用的状态，如果状态是NA，则发布的状态数组将长度为0
        /// </summary>
        NO_GOAL = -1,    // For internal server use. If status is NA, published status array will have length 0
        /// <summary>
        /// 目标尚未被操作服务器处理。这表示操作服务器尚未开始处理目标。
        /// </summary>
        PENDING,    //  The goal has yet to be processed by the action server
        /// <summary>
        /// 目标当前正在被操作服务器处理。这表示操作服务器正在执行与目标相关的操作。
        /// </summary>
        ACTIVE,     //  The goal is currently being processed by the action server
        /// <summary>
        /// 目标在开始执行后收到了取消请求，并且此后已完成执行。这是一个终止状态。意味着目标在执行过程中被取消。
        /// </summary>
        PREEMPTED,  //  The goal received a cancel request after it started executing and has since completed its execution (Terminal State)
        /// <summary>
        /// 目标已被操作服务器成功实现。这是一个终止状态。意味着目标已成功完成所需的操作。
        /// </summary>
        SUCCEEDED,  //  The goal was achieved successfully by the action server (Terminal State)

        /// <summary>
        /// 目标由于某种故障而在执行过程中被操作服务器中止。这是一个终止状态。意味着目标未能完成所需的操作。
        /// </summary>
        ABORTED,    //  The goal was aborted during execution by the action server due to some failure (Terminal State)

        /// <summary>
        /// 目标被操作服务器拒绝，未被处理，因为目标无法实现或无效。这是一个终止状态。意味着目标无法被操作服务器处理。
        /// </summary>
        REJECTED,   //  The goal was rejected by the action server without being processed, because the goal was unattainable or invalid (Terminal State)

        /// <summary>
        /// 目标在开始执行后收到了取消请求，并且尚未完成执行。这表示目标正在被取消。
        /// </summary>
        PREEMPTING, //  The goal received a cancel request after it started executing and has not yet completed execution

        /// <summary>
        /// 目标在开始执行之前收到了取消请求，但操作服务器尚未确认目标已取消。这表示目标正在进行取消操作的确认过程中。
        /// </summary>
        RECALLING,  //  The goal received a cancel request before it started executing, but the action server has not yet confirmed that the goal is canceled

        /// <summary>
        /// 目标在开始执行之前收到了取消请求，并且成功取消。这是一个终止状态。意味着目标在开始执行之前被成功取消。
        /// </summary>
        RECALLED,   //  The goal received a cancel request before it started executing and was successfully cancelled (Terminal State)

        /// <summary>
        ///  操作客户端可以确定目标已丢失。这个状态不应该通过网络发送给操作服务器。这表示操作客户端无法确定目标的状态。
        /// </summary>
        LOST,       //  An action client can determine that a goal is LOST. This should not be sent over the wire by an action server
    }
}
