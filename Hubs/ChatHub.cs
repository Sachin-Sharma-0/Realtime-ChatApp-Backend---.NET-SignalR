using ChatApp.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
        private readonly IMessageRepository _messageRepository;

        public ChatHub(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        // Method to create a new group
        public async Task CreateGroup(string groupName)
        {
            if (!groups.ContainsKey(groupName))
            {
                groups.Add(groupName, new List<string>());
                await Clients.Caller.SendAsync("GroupCreated", groupName);
            }
            else
            {
                await Clients.Caller.SendAsync("GroupExists", groupName);
            }
        }

        // Method to join a group
        public async Task JoinGroup(string groupName)
        {
            if (groups.ContainsKey(groupName))
            {
                groups[groupName].Add(Context.ConnectionId);
                await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
                await Clients.Caller.SendAsync("JoinedGroup", groupName);
            }
            else
            {
                await Clients.Caller.SendAsync("GroupNotFound", groupName);
            }
        }

        // Method to leave a group
        public async Task LeaveGroup(string groupName)
        {
            if (groups.ContainsKey(groupName) && groups[groupName].Contains(Context.ConnectionId))
            {
                groups[groupName].Remove(Context.ConnectionId);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
                await Clients.Caller.SendAsync("LeftGroup", groupName);
            }
            else
            {
                await Clients.Caller.SendAsync("NotInGroup", groupName);
            }
        }

        // Method to add a member to a group
        public async Task AddMemberToGroup(string groupName, string userId)
        {
            if (groups.ContainsKey(groupName))
            {
                groups[groupName].Add(userId);
                await Groups.AddToGroupAsync(userId, groupName);
                await Clients.Caller.SendAsync("MemberAdded", groupName, userId);
            }
            else
            {
                await Clients.Caller.SendAsync("GroupNotFound", groupName);
            }
        }

        // Method to remove a member from a group
        public async Task RemoveMemberFromGroup(string groupName, string userId)
        {
            if (groups.ContainsKey(groupName) && groups[groupName].Contains(userId))
            {
                groups[groupName].Remove(userId);
                await Groups.RemoveFromGroupAsync(userId, groupName);
                await Clients.Caller.SendAsync("MemberRemoved", groupName, userId);
            }
            else
            {
                await Clients.Caller.SendAsync("NotInGroup", groupName);
            }
        }
        // Override OnConnectedAsync method to handle user connection
        public override async Task OnConnectedAsync()
        {
            // Get the user ID of the connected user
            var userId = Context.UserIdentifier;

            // Perform tasks such as updating user lists or notifying other users about the connection

            await base.OnConnectedAsync();
        }

        // Override OnDisconnectedAsync method to handle user disconnection
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Get the user ID of the disconnected user
            var userId = Context.UserIdentifier;

            // Perform tasks such as updating user lists or notifying other users about the disconnection

            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string senderId, string recipientId, string message)
        {
            // Broadcast the message to the recipient only
            await Clients.User(recipientId).SendAsync("ReceiveMessage", senderId, message);
        }

        // Method to send a message to a group
        public async Task SendMessageToGroup(string groupName, string senderId, string message)
        {
            // Broadcast the message to all clients in the specified group
            await Clients.Group(groupName).SendAsync("ReceiveMessage", senderId, message);
        }

        // Method to add a user to a group
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        // Method to remove a user from a group
        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        // Method to receive messages from a group
        public async Task ReceiveMessageFromGroup(string groupName, string senderId, string message)
        {
            // You can handle the received message from the group as needed
            // For example, you can forward the message to the clients or perform other actions
            await Clients.All.SendAsync("ReceiveMessage", senderId, message);
        }
    }
}
