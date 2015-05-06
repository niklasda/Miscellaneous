using System.Collections.Generic;
using System.Web.UI.WebControls;
using nida.model;
using Spring.Context;
using Spring.Context.Support;

namespace nida.presenter
{
    public class UserDetailPresenter
    {
        private DataList _view;
        private int _userId;
        private LinkButton _button;
        private IUserHandler _userHandler;

        public UserDetailPresenter(int userId, DataList view, LinkButton button)
        {
            _userId = userId;
            _view = view;
            _button = button;

            IApplicationContext ctx = ContextRegistry.GetContext();
            _userHandler = (IUserHandler)ctx.GetObject("MyUserHandler");
        }

        public void ShowHide()
        {
            if (_view.Visible)
            {
                _view.Visible = false;
                _button.Text = "Show";
            }
            else
            {
                List<MyChild> children = _userHandler.RetrieveChildren(_userId);

                _view.DataSource = children;
                _view.DataBind();
                _view.Visible = true;
                _button.Text = "Hide";
            }
        }
    }
}