using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using nida.presenter;
using LinkButton=Anthem.LinkButton;

namespace nida.ui
{
    public partial class UserList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserListPresenter presenter = new UserListPresenter(UserDataList);
                presenter.ShowUsers();
            }
        }

        protected void ExpandButton_Click(object sender, EventArgs e)
        {
            LinkButton expandButton = (LinkButton) sender;
            int userId = Convert.ToInt32(expandButton.CommandArgument);

            DataListItem DataListItem = (DataListItem) expandButton.Parent;
            DataList userDetailsDataList = (DataList) DataListItem.FindControl("UserDetailsDataList");

            UserDetailPresenter presenter = new UserDetailPresenter(userId, userDetailsDataList, expandButton);
            presenter.ShowHide();
        }
    }
}