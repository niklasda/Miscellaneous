using System;
using Gallio.Model;
using Gallio.Runner;
using Gallio.Runner.Events;
using Gallio.Runner.Extensions;
using Gallio.Runner.Reports.Schema;
using Gallio.Runtime.Logging;
using Gallio.Runtime.ProgressMonitoring;

namespace MbUnitDemo.Tests.Rolling
{
    /// <summary>
    /// A test runner provides the basic functionality for loading, 
    /// exploring and running tests.
    /// </summary>
    public class YourOwn : ITestRunner
    {
        /// <summary>
        /// Registers a test runner extension.
        /// </summary>
        /// <param name="extension">The test runner extension to register.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="extension"/> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the test runner has already been initialized.</exception>
        public void RegisterExtension(ITestRunnerExtension extension)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes the test runner.
        /// </summary>
        /// <param name="testRunnerOptions">The test runner options.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="progressMonitor">The progress monitor.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="testRunnerOptions"/>,<paramref name="logger"/> or <paramref name="progressMonitor"/> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the runner is already initialized.</exception>
        /// <exception cref="T:System.ObjectDisposedException">Thrown if the runner has been disposed.</exception>
        public void Initialize(TestRunnerOptions testRunnerOptions, ILogger logger, IProgressMonitor progressMonitor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Explores tests in a test package.
        /// </summary>
        /// <param name="testPackage">The test package.</param>
        /// <param name="testExplorationOptions">The test exploration options.</param>
        /// <param name="progressMonitor">The progress monitor.</param>
        /// <returns>
        /// The test report.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="testPackage"/>,<paramref name="testExplorationOptions"/>, or <paramref name="progressMonitor"/> is null.</exception>
        /// <exception cref="T:Gallio.Runner.RunnerException">Thrown if the operation failed.</exception>
        /// <exception cref="T:System.ObjectDisposedException">Thrown if the runner has been disposed.</exception>
        public Report Explore(TestPackage testPackage, TestExplorationOptions testExplorationOptions, IProgressMonitor progressMonitor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Explores and runs tests in a test package.
        /// </summary>
        /// <param name="testPackage">The test package.</param>
        /// <param name="testExplorationOptions">The test exploration options.</param>
        /// <param name="testExecutionOptions">The test execution options.</param>
        /// <param name="progressMonitor">The progress monitor.</param>
        /// <returns>
        /// The test report.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="testPackage"/>,
        ///             <paramref name="testExplorationOptions"/>, <paramref name="testExecutionOptions"/>, or <paramref name="progressMonitor"/> is null.</exception>
        /// <exception cref="T:Gallio.Runner.RunnerException">Thrown if the operation failed.</exception>
        /// <exception cref="T:System.ObjectDisposedException">Thrown if the runner has been disposed.</exception>
        public Report Run(TestPackage testPackage, TestExplorationOptions testExplorationOptions, TestExecutionOptions testExecutionOptions, IProgressMonitor progressMonitor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disposes the test runner.  Does nothing if already disposed or if not initialized.
        /// </summary>
        /// <param name="progressMonitor">The progress monitor.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="progressMonitor"/> is null.</exception>
        public void Dispose(IProgressMonitor progressMonitor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the event dispatcher for the test runner.
        /// </summary>
        public ITestRunnerEvents Events
        {
            get { throw new NotImplementedException(); }
        }
    }
}